        public void Close()
        {
            if (this.unsavedChange)
            {
                DialogResult dr = MessageBox.Show("Le formulaire présentement ouvert contient des données qui n'ont pas été sauvegardées. Voulez-vous les enregistrés avant de poursuivre?",
                                                        "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    this.Save();
                }
            }
        }
