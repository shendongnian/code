     /// <summary>
     /// Gets the SVN date.
     /// </summary>
     /// <value>The SVN date. value</value>
    // ReSharper disable UnusedMember.Global
    public static new string SvnDate{
      // ReSharper restore UnusedMember.Global
      get {
        const string S = "$Date$";
        return S.Substring(7, 19);
      }
    }
     /// <summary>
     /// Gets the SVN ID.
     /// </summary>
     /// <value>The SVN ID. value</value>
    // ReSharper disable UnusedMember.Global
    public static new string SvnID{
      // ReSharper restore UnusedMember.Global
      get{
        const string S = "$Id$";
        const string D = "$";
        return S.Replace(D + "Id: ", string.Empty).Replace(" " + D, string.Empty);
      }
    }
     /// <summary>
     /// Gets the SVN rev.
     /// </summary>
     /// <value>The SVN rev. value</value>
    // ReSharper disable UnusedMember.Global
    // ReSharper disable MemberCanBePrivate.Global
    public static new string SvnRev{
      // ReSharper restore MemberCanBePrivate.Global
      // ReSharper restore UnusedMember.Global
      get {
        const string S = "$Rev$";
        return S.Item(1);
      }
    }
     /// <summary>
     /// Gets the SVN author.
     /// </summary>
     /// <value>The SVN author. value</value>
    // ReSharper disable UnusedMember.Global
    public static new string SvnAuthor{
      // ReSharper restore UnusedMember.Global
      get {
        const string S = "$Author$";
        return S.Item(1);
      }
    }
