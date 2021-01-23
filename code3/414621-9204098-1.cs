	namespace EnumerableDT
	{
		class Program
		{
			public class Information
			{
				public int APPLICATION_ID { get; set; }
				public string HOSPITAL_NAME { get; set; }
				public string PHYSICAL_ADDRESS { get; set; }
				public string SOME_OTHER_FIELD { get; set; }
			}
			static DataSet dsp = new DataSet();
			static void Main(string[] args)
			{
				dsp.Tables.Add(BuildDataTableStructure());
				dsp.Tables[0].Rows.Add(BuildRow());
				AutoMapper.Mapper.Reset();
				AutoMapper.Mapper.CreateMap<IDataReader, Information>();
				var il = AutoMapper.Mapper.Map<IDataReader, IList<Information>>(dsp.Tables[0].CreateDataReader());
				Console.ReadLine();
			}
			static DataTable BuildDataTableStructure()
			{
				var dt = new DataTable();
				var dc = new DataColumn("APPLICATION_ID", typeof(int));
				dt.Columns.Add(dc);
				dc = new DataColumn("HOSPITAL_NAME", typeof(string));
				dt.Columns.Add(dc);
				dc = new DataColumn("PHYSICAL_ADDRESS", typeof(string));
				dt.Columns.Add(dc);
				dc = new DataColumn("SOME_OTHER_FIELD", typeof(string));
				dt.Columns.Add(dc);
				return dt;
			}
			static DataRow BuildRow()
			{
				DataRow dr = dsp.Tables[0].NewRow();
				dr["APPLICATION_ID"] = 1;
				dr["HOSPITAL_NAME"] = "The Hospital";
				dr["PHYSICAL_ADDRESS"] = "123 Main St.";
				dr["SOME_OTHER_FIELD"] = "Some Other Data";
				return dr;
			}
		}
	}
