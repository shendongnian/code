    private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                item = listBox1.SelectedItem.ToString();
                this.f1.PlayLightnings();
                f1.pdftoolsmenu();
                if (item != null && !pdf1.Lightnings.Contains(item.ToString()))
                {
                    pdf1.Lightnings.Add(item.ToString());
                    itemExist = true;                
                }
            }
