	string s = string.Empty;
	PassingID1 passingid1;
	passingid1.Text = s; //This will cause a NullReferenceException because passingid1 is null
	PassingID2 passingid2 = new PassingID2();
	passingid2.Text = s; //This will cause a NullReferenceException because _Text is null
