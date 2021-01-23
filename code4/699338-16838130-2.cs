          public int PageNum
          {
              get { return string.IsNullOrEmpty(PageNum.Value) ? 0 : int.Parse(PageNum.Value); }
              set { PageNum.Value = value.ToString(CultureInfo.InvariantCulture); }
          }
