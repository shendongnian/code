    Utils u = new Utils(); 
    QueryBuilder newQRY = new QueryBuilder(); 
    string Command = "SELECT  Cast.Submit_Date, Cast.Cast_ID, Cast.Game_Frame, Cast.Race_1, Cast.Race_2, Cast.Language, Cast.Map, Cast.Serie_Name, Cast.Cast_URL, Cast.Like_Amount, Caster.Caster_LOGO, Caster.Caster_Name, Player.Player_Name, Player_1.Player_Name AS Expr1 FROM Cast INNER JOIN Caster ON Cast.Caster = Caster.Caster_ID INNER JOIN Player ON Cast.Player1 = Player.Player_ID INNER JOIN Player AS Player_1 ON Cast.Player2 = Player_1.Player_ID ORDER BY Cast.Submit_date"; 
    SqlConnection connString = u.connect("NewConnectionString"); 
    SqlDataAdapter adpWatchLaterSession = new SqlDataAdapter(Command, connString); 
    DataSet dscasts = new DataSet(); 
    adpWatchLaterSession.Fill(dscasts); 
    DataTable dt = new DataTable(); 
    string watchLaterCastsQRY = newQRY.buildCastIDrelatedtoUserQuary(); 
    adpWatchLaterSession = new SqlDataAdapter(watchLaterCastsQRY, connString); 
    adpWatchLaterSession.Fill(dt); 
SqlConnection, SqlDataAdapter, SqlCommand and DataSet implement IDisposable you should call dispose method.
You could do it automatically if you use the instruction [using](http://msdn.microsoft.com/en-us/library/yh598w02(v=vs.80)). For example:
    using(var conn = new SqlConnection("connectionstring"))
    {
       ....
    }  
