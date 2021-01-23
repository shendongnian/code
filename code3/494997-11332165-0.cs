            //inside initialization void
            dgvData.CellFormatting+=new DataGridViewCellFormattingEventHandler(dgvData_CellFormatting);
            dvcol = new DataGridViewTextBoxColumn();
            dgvData.Columns.Add(dvcol);
        }
        DataGridViewColumn dvcol;
        void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dvcol != null && e.RowIndex != -1 && e.ColumnIndex == dvcol.Index)//where Column1 is your combobox column
            {
                var rec = (YourRecordTypeSuchAsContract)dgvData.Rows[e.RowIndex].DataBoundItem;
                e.Value = ""; //get description based on the rec
            }
        }
