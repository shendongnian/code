      public static DateTime PersianDateStringToDateTime(this string persianDate)
      {
            PersianCalendar pc = new PersianCalendar();
            var persianDateSplitedParts = persianDate.Split('/');
            DateTime dateTime = new DateTime(int.Parse(persianDateSplitedParts[0]), int.Parse(persianDateSplitedParts[1]), int.Parse(persianDateSplitedParts[2]), pc);
            return DateTime.Parse(dateTime.ToString(CultureInfo.InvariantCulture));
      }
