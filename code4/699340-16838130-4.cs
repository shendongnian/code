          public int PageNum
          {
              get { return string.IsNullOrEmpty(hfPageNum.Value) ? 0 : int.Parse(hfPageNum.Value); }
              set { hfPageNum.Value = value.ToString(CultureInfo.InvariantCulture); }
          }
