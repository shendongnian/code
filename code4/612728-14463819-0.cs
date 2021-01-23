        using System;
        using System.IO;
        using System.Windows.Forms;
        namespace WindowsFormsApplication6
        {
            public partial class Form1 : Form
            {
                private string destinationFolder;
                private ListView listView1;
                public Form1()
                {
                    // Set destinationFolder to MyDocuments - for test
                    this.destinationFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    InitializeComponent();
                    this.listView1.Clear();
                    foreach (var dir in Directory.GetDirectories(destinationFolder))
                    {
                        this.listView1.Items.Add(new ListViewItem() { Name = dir, Text = Path.GetFileName(dir) });
                    }
                }
                private void SetListViewItemName(int index, string name)
                {
                    if (this.listView1.Items.Count < index)
                    {
                        this.listView1.Items[index].Name = name;
                    }
                }
                private string GetListViewItemText(int index)
                {
                    if (this.listView1.Items.Count < index)
                    {
                        return this.listView1.Items[index].Text;
                    }
                    else
                    {
                        return String.Empty;
                    }
                }
        
                private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
                {
                    try
                    {
                        string itemText = GetListViewItemText(e.Item);
                        string sourceDirName = Path.Combine(new string[] { this.destinationFolder, itemText });
                        string destDirName = Path.Combine(new string[] { this.destinationFolder, e.Label });
                        // Rename the old directory.
                        Directory.Move(sourceDirName, destDirName);
                        SetListViewItemName(e.Item, destDirName);
                    }
                    catch (Exception ex)
                    {
                        // Error occured, cancel edit.
                        // Empty text, cancel edit.
                        // There are few more things to check: max pathlength, invalid chars etc.
                        e.CancelEdit = true;
                    }
                }
                private void InitializeComponent()
                {
                    this.listView1 = new System.Windows.Forms.ListView();
                    this.SuspendLayout();
                    // 
                    // listView1
                    // 
                    this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.listView1.LabelEdit = true;
                    this.listView1.Location = new System.Drawing.Point(0, 0);
                    this.listView1.Name = "listView1";
                    this.listView1.Size = new System.Drawing.Size(284, 262);
                    this.listView1.TabIndex = 0;
                    this.listView1.UseCompatibleStateImageBehavior = false;
                    this.listView1.View = System.Windows.Forms.View.List;
                    this.listView1.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView1_AfterLabelEdit);
                    //this.listView1.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView1_BeforeLabelEdit);
                    // 
                    // Form1
                    // 
                    this.ClientSize = new System.Drawing.Size(284, 262);
                    this.Controls.Add(this.listView1);
                    this.Name = "Form1";
                    this.ResumeLayout(false);
                }
            }
        }
