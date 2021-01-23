    public void createTxtTeamNames()
            {
                TextBox[] txtTeamNames = new TextBox[10];
                
    for (int u = 0; u < txtTeamNames.Count(); u++)
                {
                    txtTeamNames[u] = new TextBox();
                }
                int i = 0;
                foreach (TextBox txt in txtTeamNames)
                {
                    string name = "TeamNumber" + i.ToString();
                    
                    txt.Name = name;
                    txt.Text = name;
                    txt.Location = new Point(0, 32 + (i * 28));
                    txt.Visible = true;
                    this.Controls.Add(txt);
                    i++;
                }
            }
