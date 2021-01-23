	String a = "DesinfektionslÃƒÂ¶sungstÃƒÂ¼cher fÃƒÂ¼r FlÃƒÂ¤chen";
	Encoding utf8 = Encoding.GetEncoding(65001);
	Encoding win1252 = Encoding.GetEncoding(1252);
	string result = utf8.GetString(win1252.GetBytes(utf8.GetString(win1252.GetBytes(a))));
	Console.WriteLine(result);
	//Desinfektionslösungstücher für Flächen
