    bool IsChecked=false;
    private void tv_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    {
        if (!IsChecked&&IsCtrlFormUnsave())
        {
            e.Cancel = true;
            //Invoke(new Action(AvertirUser)); //this is in case the save action didn't worked
        }
    }
    
    private bool IsCtrlFormUnsave()
    {
        IsChecked=true; //set it to true to jump out of the loop
        if (_ctrlForm != null && _ctrlForm.unsavedChange)
        {   
            
            DialogResult dr = MessageBox.Show("Le formulaire présentement ouvert contient des données qui n'ont pas été sauvegardées. Voulez-vous les enregistrés avant de poursuivre?",
                                                    "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
                if (!_ctrlForm.Save())
                    return true;
    
            _ctrlForm = null;
        }
        return false;
    }
