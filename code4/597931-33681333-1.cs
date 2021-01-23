        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Override behavior on Enter press
            if (keyData == Keys.Enter)
            {
                if (CurrentCell != null)
                {
                    if (CurrentCell.IsInEditMode)
                    {
                        //Do Stuff if cell is currently being edited
                        return ProcessTabKey(keyData);
                    }
                    else
                    {
                        //Do Stuff if cell is NOT yet currently edited
                        BeginEdit(true);
                    }
                }
            }
            //Process all other keys as expected
            return base.ProcessCmdKey(ref msg, keyData);
        }
