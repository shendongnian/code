    public partial class frmGroupNameLookup : Form
    {
        //add a delegate, the GroupNameLookupUpdateEventArgs class is defined at the bottom
        //of this file
        public delegate void LookupHandler(object sender, GroupNameLookupUpdateEventArgs e);
        //add an event of the delegate type
        public event LookupHandler GroupNamesFound;
        //this event closes the forms and passes 2 lists back to form 1
        private void btnCommit_Click(object sender, EventArgs e)
        {
            List<string> prnt = new List<string>();
            List<string> grp = new List<string>();
            //get selected rows
            if (grdLookup.SelectedRows.Count > 0)
            {
                
                foreach (DataGridViewRow row in grdLookup.SelectedRows)
                {
                    prnt.Add(row.Cells[0].Value.ToString());
                    grp.Add(row.Cells[1].Value.ToString());
                }
            
                //filter out duplicates 
                var noDupeParentGroups = prnt.Distinct().ToList();
                noDupeParentGroups.Sort();
                // instance the event args and pass it each value
                GroupNameLookupUpdateEventArgs args =
                    new GroupNameLookupUpdateEventArgs(noDupeParentGroups, grp);
                // raise the event with the updated arguments
                this.GroupNamesFound(this, args);
                this.Dispose();
            }
        }
    }
    public class GroupNameLookupUpdateEventArgs : System.EventArgs
    {
        // add local member variables to hold text
        private List<string> mParents = new List<string>();
        private List<string> mGroups = new List<string>();
        
        // class constructor
        public GroupNameLookupUpdateEventArgs(List<string> sParents, List<string> sGroups)
        {
            this.mParents = sParents;
            this.mGroups = sGroups;
        }
        // Properties - Viewable by each listener
        public List<string> Parents
        {
            get { return mParents; }
        }
        public List<string> Groups
        {
            get { return mGroups; }
        }
    }
