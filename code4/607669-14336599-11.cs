    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    //using System.Linq;
    using System.Text;
    //using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication10
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.listBox1.DisplayMember = "Name";/*to display name on listbox*/
                this.listBox1.ValueMember = "FullName";/*to fetch item value on listbox*/
                listBox1.DataSource = GetFolder("..\\video\\"); /*gets folder path*/ 
            }
            private static List<FileInfo> GetFolder(string folder)
            {
                List<FileInfo> fileList = new List<FileInfo>();
                foreach (FileInfo file in new DirectoryInfo(folder)
                                             .GetFiles("*.mpg", SearchOption.AllDirectories))
                {
                    fileList.Add(file);
                }
                return fileList;
            }
            private void button1_Click(object sender, EventArgs e)
            {
                Form3 frm = new Form3();
                frm.FormClosed += frm_FormClosed;
                foreach (int i in listBox1.SelectedIndices)
                {
                    frm.listBox2.Items.Add(new 
                    { 
                        Name = ((FileInfo)listBox1.Items[i]).Name, 
                        FullName = ((FileInfo)listBox1.Items[i]).FullName 
                    });
                    frm.Show();
                    this.Hide();
                }
            }
            void frm_FormClosed(object sender, FormClosedEventArgs e)
            {
                this.Show();
            }
        }
    }
