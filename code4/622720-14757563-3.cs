    public class AddSourceFiles : Task
    {
        private ITaskItem[] output = null;
        [Output]
        public ITaskItem[] Output
        {
            get
            {
                return output;
            }
        }
        public override bool Execute()
        {
            //gather a list of files to add:
            List<string> filepaths = new List<string>() { "a.cs", "b.cs", "d.cs" };
            //convert the list to a itaskitem array and set it as output
            output = new ITaskItem[filepaths.Count];
            int pos = 0;
            foreach (string filepath in filepaths)
            {
                output[pos++] = new TaskItem(filepath);
            }
        }
    }
