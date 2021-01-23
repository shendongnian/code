	public ref struct Date_ms
	{
		AutoPtr<Date_s> data;
		Date_ms()
		{
			data = new Date_s();
		}
		property unsigned nWeekDay
		{
			unsigned get() { return data->nWeekDay; }
			void set(unsigned value) { data->nWeekDay = value; }
		}
		property unsigned nMonthDay
		{
			unsigned get() { return data->nMonthDay; }
			void set(unsigned value) { data->nMonthDay = value; }
		}
		property unsigned nMonth
		{
			unsigned get() { return data->nMonth; }
			void set(unsigned value) { data->nMonth = value; }
		}
		property unsigned nYear
		{
			unsigned get() { return data->nYear; }
			void set(unsigned value) { data->nYear = value; }
		}
		property unsigned bob
		{
			unsigned get() { return data->bob; }
			void set(unsigned value) { data->bob = value; }
		}
	};
