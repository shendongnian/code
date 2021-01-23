     /// <summary>
        /// The purpose of this method is two fold.  First it stops the data grid
        /// from adding a new row when the enter key is pressed during editing a cell
        /// Secondly it filters the keys for numeric characters only when the selected 
        /// cell type is of a numeric type.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Let's get fancy and detect the column type and then filter the keys as needed.
            if (!dgListData.IsCurrentCellInEditMode) return base.ProcessCmdKey(ref msg, keyData); //only go into the routine if we are in edit mode
            
            if (helper.IsNumericType(dgListData.CurrentCell.ValueType))
            {
                if (helper.NumericFilterKeyData(keyData)) return true; //override the key
            }
            // Check if Enter is pressed
            if (keyData != Keys.Enter) return base.ProcessCmdKey(ref msg, keyData);
            // If there isn't any selected row, do nothing
            
            SetFocusToNextVisibleColumn(dgListData);
            return true;
        }
        private void SetFocusToNextVisibleColumn(DataGridView dgViewTarget)
        {
            if (dgViewTarget.CurrentCell == null) return;
            Console.WriteLine(dgViewTarget.CurrentCell.Value);
            
            if (dgViewTarget.CurrentCell.IsInEditMode) dgViewTarget.EndEdit();
            var currentColumn = dgViewTarget.CurrentCell.ColumnIndex;
            if (currentColumn < dgViewTarget.ColumnCount) ++currentColumn;
            for (var i = currentColumn; i < dgViewTarget.ColumnCount; i++)
            {
                if (!dgViewTarget[i, dgViewTarget.CurrentRow.Index].Displayed) continue;
                dgViewTarget.CurrentCell = dgViewTarget[i, dgViewTarget.CurrentRow.Index];
                break;
            }
        }
