    string[] words = masg.Split('~');
            int size = words.Length;
            CheckBox[] cbl = new CheckBox[size];
            for (int i = 0; i < words.Length; i++)
            {
                cbl[i] = new CheckBox();
                cbl[i].Text = words[i].ToString();
                pnlControls.Controls.Add(cbl[i]); 
               // Response.Write("\n" + words[i]);
            }
