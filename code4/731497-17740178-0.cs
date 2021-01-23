        public override void OnDeleting(PSContextInfo contextInfo, ProjectPreEventArgs e)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\Blah.txt"))
            {
                sw.WriteLine("Happy days");
            }
        }
