    	private void btnRefresh_Click(object sender, EventArgs e) 
		{ 
			this.RefreshData();
		}
		public void RefreshData()
		{
			GVThesis.DataSource = thesisRepository.GetThesis(); 
			GVThesis.Refresh(); 
		}
