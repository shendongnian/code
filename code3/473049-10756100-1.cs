     private void listView1_OnColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            ListViewSorter Sorter = new ListViewSorter();
            listView1.ListViewItemSorter = Sorter;
            if (!(listView1.ListViewItemSorter is ListViewSorter))
                return;
            Sorter = (ListViewSorter) listView1.ListViewItemSorter;
            if (Sorter.LastSort == e.Column)
            {
                if (listView1.Sorting == SortOrder.Ascending)
                    listView1.Sorting = SortOrder.Descending;
                else
                    listView1.Sorting = SortOrder.Ascending;
            }
            else{
                listView1.Sorting = SortOrder.Descending;
            }
            Sorter.ByColumn = e.Column;
            listView1.Sort ();
        }
----------------------------
 
       public class ListViewSorter : System.Collections.IComparer
        {
            public int Compare (object o1, object o2)
            {
                if (!(o1 is ListViewItem))
                    return (0);
                if (!(o2 is ListViewItem))
                    return (0);
    
                ListViewItem lvi1 = (ListViewItem) o2;
                string str1 = lvi1.SubItems[ByColumn].Text;
                ListViewItem lvi2 = (ListViewItem) o1;
                string str2 = lvi2.SubItems[ByColumn].Text;
    
                int result;
                if (lvi1.ListView.Sorting == SortOrder.Ascending)
                    result = String.Compare (str1, str2);
                else
                    result = String.Compare (str2, str1);
    
                LastSort = ByColumn;
    
                return (result);
            }
    
    
            public int ByColumn
            {
                get {return Column;}
                set {Column = value;}
            }
            int Column = 0;
    
            public int LastSort
            {
                get {return LastColumn;}
                set {LastColumn = value;}
            }
            int LastColumn = 0;
        }   
    			
