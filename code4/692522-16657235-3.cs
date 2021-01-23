    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
      public partial class Form1 : Form
      {
        public Form1()
        {
          InitializeComponent();
          this.SuspendLayout();
    
          // This part is just setting up the ListView 
          // Turn off default sorting, and set to display columns
          this.listView1.Sorting = SortOrder.None;
          this.listView1.View = View.Details;
    
          // Add two columns (ColumnA and ColumnB)
          this.listView1.Columns.Add(new ColumnHeader());
          this.listView1.Columns[0].Width = 100;
          this.listView1.Columns[0].Text = "ColumnA";
          this.listView1.Columns.Add(new ColumnHeader());
          this.listView1.Columns[1].Width = 100;
          this.listView1.Columns[1].Text = "ColumnB";
    
          // Add the actual column information
          ListViewItem listViewItem1 = new ListViewItem(new String[] {"three", "banana"});
          ListViewItem listViewItem2 = new ListViewItem(new String[] {"one", "c"});
          ListViewItem listViewItem3 = new ListViewItem(new String[] {"one", "b"});
          ListViewItem listViewItem4 = new ListViewItem(new String[] {"three", "apricot"});
          this.listView1.Items.AddRange(new ListViewItem[]{listViewItem1, 
                                                           listViewItem2, 
                                                           listViewItem3, 
                                                           listViewItem4});
          /*
             Now the actual sorting - this next line makes it sort using 
             the custom comparer we've defined. Assigning a new IComparer
             automatically sorts using it.
          */
          this.listView1.ListViewItemSorter = new ListViewItemComparer();
          this.ResumeLayout(false);
        }
      }
    
      // Implements the manual sorting of items by columns. 
      class ListViewItemComparer : IComparer  
      {
        public ListViewItemComparer()
        {
           
        }
        // This function actually does the comparison     
        public int Compare(object x, object y)
        {
          /* 
             We need to access the same item multiple times, so
             save a local reference to reduce typecasting over and
             over again
          */
          ListViewItem FirstItem = (ListViewItem) x;
          ListViewItem SecondItem = (ListViewItem) y;
          /* 
             Compare the two columns of each item, combined to make 
             a single item for comparing.
          */
          return String.Compare(FirstItem.SubItems[0].Text + FirstItem.SubItems[1].Text,
                                SecondItem.SubItems[0].Text + SecondItem.SubItems[1].Text);
        }
      }
    }
