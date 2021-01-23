            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "xpdl 2.1|*.xpdl|xpdl 2.2|*.xpdl";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                switch (dlg.FilterIndex)
                {
                    case 1:
                        //selected xpdl 2.1
                        break;
                    case 2:
                        //selected xpdl 2.2
                        break;
                }
            }
