        public override void OnDeleting(PSContextInfo contextInfo, ProjectPreEventArgs e)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\Blah.txt"))
            {
                string textToWrite = string.Format("Пользователь \"{0}\" удалил проект \"{1}\"", contextInfo.UserName, e.ProjectName);
                sw.WriteLine(textToWrite);
            }
        }
