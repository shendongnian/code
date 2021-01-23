		Public Main()
		{	
			//Generate a list of Tuples using linq
			var tuples = from row in dataGridView1.Rows.Cast<DataGridViewRow>()
						 select new Tuple<double, double>(
							 Convert.ToDouble(row.Cells["longitude"].Value), 
							 Convert.ToDouble(row.Cells["latitude"].Value));
			//Pass the tuple list to DoSomethingMethod
			DoSomethingMethod(tuples);
		}
		private void DoSomeThing(IEnumerable<Tuple<double, double>> tuples)
		{
			//Iterate through the tuples
			foreach (Tuple<double, double> tuple in tuples)
			{
				double myX = tuple.Item1;
				double myY = tuple.Item2;
			}
		}
