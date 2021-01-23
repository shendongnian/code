            dgv.Columns.RemoveAt(<NumberColumn2Remove>);
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn;
            chk.HeaderText = "<HeaderText>";
            chk.Name = "<WhatEver>";
            chk.DataPropertyName = "<DataField2Bind2>";
            dgv.Columns.Insert(<NumberColumn2Insert>, chk);
