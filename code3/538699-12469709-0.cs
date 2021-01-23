    	private void btnRefresh_Click(object sender, EventArgs e) 
		{ 
			this.RefreshData();
		}
		private void RefreshData()
		{
			GVThesis.DataSource = thesisRepository.GetThesis(); 
			GVThesis.Refresh(); 
		}
