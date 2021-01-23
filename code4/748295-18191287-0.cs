    string x = "'DRCI',1,'P','CALLIN_DATE,DRIV_EMPL_CODE'";
    string[] y = x.Split(",".ToCharArray());
    for (int i = 0; i < y.Length; i++) {
    	if (Information.IsNumeric(y[i]))
    		y[i] = "'" + y[i] + "'";
    }
    x = string.Join(",", y);
