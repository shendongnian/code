    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
           crawlLocaly1 = new CrawlLocaly();
           crawlLocaly1.StartPosition = FormStartPosition.CenterParent;
           OptionsDB.Set_localOnly(checkBox2.Checked);
    
           // UPDATED
           if (checkedInThisSession && checkBox2.Checked)
           {
               DialogResult dr = crawlLocaly1.ShowDialog(this);
               // ...
           }
           else
           {
               removeExt = false;
           }
    
    
           // UPDATED
           checkedInThisSession = checkBox2.Checked;
    }
           
    // In constructor    
    checkedInThisSession = false;
    checkBox2.Checked = OptionsDB.Get_localOnly(); 
