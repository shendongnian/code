    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Threading;
    using System.Management;
    using System.Diagnostics;
    namespace Admin_Helper
    {
    public partial class frmRemoteInformation : Form
    {
        public frmRemoteInformation()
        {
            InitializeComponent();
        }
        string strServername;
        string strUsername;
        string strPassword;
        string strClassSelection;
        ConnectionOptions rcOptions;
        ManagementObjectCollection moCollection;
        ObjectQuery oQuery;
        ManagementObjectSearcher moSearcher;
        ManagementScope mScope;
        
        private void frmRemoteInformation_Load(object sender, EventArgs e)
        {
            if (mScope.IsConnected == true) { lblConnectionStateWarning.Text = "Connected"; } else { lblConnectionStateWarning.Text = "Disconnected"; } //I have a label that displays connectionstate, you can leave that out
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                strServername = txtServer.Text;
                strUsername = txtUsername.Text;
                strPassword = txtPassword.Text;
                remoteConnection(strServername, strUsername, strPassword);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void cmbClassSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
                var dctPropertyList = new Dictionary<string, string>();
                strClassSelection = cmbClassSelection.SelectedItem.ToString();
                new Thread(() => FindWMI(strServername, strClassSelection, rcOptions, dctPropertyList, lstProperties)).Start();
        }
        private void remoteConnection(string servername, string username, string password)
        {
            try
            {
                rcOptions = new ConnectionOptions();
                rcOptions.Authentication = AuthenticationLevel.Packet;
                rcOptions.Impersonation = ImpersonationLevel.Impersonate;
                rcOptions.EnablePrivileges = true;
                rcOptions.Username = servername + @"\" + username;
                rcOptions.Password = password;
                mScope = new ManagementScope(String.Format(@"\\{0}\root\cimv2", servername), rcOptions);
                mScope.Connect();
                if (mScope.IsConnected == true) { MessageBox.Show("Connection Succeeded", "Alert"); } else { MessageBox.Show("Connection Failed", "Alert"); }
                if (mScope.IsConnected == true) { lblConnectionStateWarning.Text = "Connected"; } else { lblConnectionStateWarning.Text = "Disconnected"; } //I have a label that displays connectionstate, you can leave that out
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void FindWMI(string servername, string classSelection, ConnectionOptions rcOptions, Dictionary<string, string> dct, ListView listView)
        {
            try
            {
                List<ListViewItem> itemsList = new List<ListViewItem>();
                oQuery = new ObjectQuery("select * from " + classSelection);
                moSearcher = new ManagementObjectSearcher(mScope, oQuery);
                moCollection = moSearcher.Get();
                Invoke(new MethodInvoker(() =>
                {
                    listView.Items.Clear();
                }));
                foreach (ManagementObject mObject in moCollection)
                {
                    if (mObject != null)
                    {
                        foreach (PropertyData propData in mObject.Properties)
                        {
                            if (propData.Value != null && propData.Value.ToString() != "" && propData.Name != null && propData.Name != "")
                                dct[propData.Name] = propData.Value.ToString();
                        }
                    }
                }
                foreach (KeyValuePair<string, string> listItem in dct)
                {
                    ListViewItem lstItem = new ListViewItem(listItem.Key);
                    lstItem.SubItems.Add(listItem.Value);
                    itemsList.Add(lstItem);
                }
                Invoke(new MethodInvoker(() =>
                {
                    listView.Items.AddRange(itemsList.ToArray());
                }));
            }
            catch (Exception) { }
        }
        private void frmRemoteInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
            {
                if (myProc.ProcessName == "WmiPrvSE")
                {
                    myProc.Kill();
                }
            }
            if (mScope.IsConnected == true) { mScope.Options.Authentication = AuthenticationLevel.None; }; //Change option so that the connection closes, no disconnect option
        }
    }
    }
