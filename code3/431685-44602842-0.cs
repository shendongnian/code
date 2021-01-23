        bool _dgv_list_cellEndEdit = false; // class level variable
        void dataGridView1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
   			{
				e.SuppressKeyPress=true;
   				SendKeys.Send("{Tab}");
			}
		}
		void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			_dgv_list_cellEndEdit=true;
		}
		void dataGridView1_MouseDown(object sender, MouseEventArgs e)
		{
			_dgv_list_cellEndEdit=false;
		}
		void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if(_dgv_list_cellEndEdit)
			{
				_dgv_list_cellEndEdit=false;
				SendKeys.Send("{Up}");
				SendKeys.Send("{Tab}");
			}
		}
