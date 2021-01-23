        private static void FreezeBand(DataGridViewBand band)
    	{
    		band.Frozen = true;
    		DataGridViewCellStyle style = new DataGridViewCellStyle();
    		style.BackColor = Color.WhiteSmoke;
    		band.DefaultCellStyle = style;
    	}
