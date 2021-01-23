            //Regex regex = new Regex("([a-zA-Z0-9 ._@]+)");
            Regex regex = new Regex("^[a-zA-Z0-9_@(+).,-]+$");
            string alltxt = txtOthers.Text;//txtOthers is textboxes name;
            int k = alltxt.Length;
            for (int i = 0; i <= k - 1; i++)
            {
 
                string lastch = alltxt.Substring(i, 1);
                MatchCollection matches = regex.Matches(lastch);
                if (matches.Count > 0)
                {
                }
                else
                {
                    txtOthers.Text = alltxt.Remove(i, 1);
                    i = i - 1;
                    alltxt = txtOthers.Text;
                    k = alltxt.Length;
                }
                txtOthers.Select(txtOthers.TextLength, 0);
            }
        
