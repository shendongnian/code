                if (!e.Cancelled && e.Error == null && !String.IsNullOrEmpty(e.Result))
                {
                    _artistas = new List<Artista>();
                    // Aqui você pega todos os links da página
                    // P.S.: Se a página mudar, você tem que alterar o pattern aqui.
                    string pattern = @"\<a\shref\=[\""|\'](?<url>[^\""|\']+)[\""|\']\stitle\=[\""|\'](?<title>[^\""|\']+)[\""|\']\>(?<author>[^\<]+)\<\/a\>";
                    // Busca no HTML todos os links
                    MatchCollection ms = Regex.Matches(e.Result, pattern, RegexOptions.Multiline);
    
                    Debug.WriteLine("----- OK {0} links encontrados", ms.Count);
    
                    foreach (Match m in ms)
                    {
                        // O pattern acima está dizendo onde fica o Url e onde fica o nome do artista
                        // e esses são resgatados aqui
                        Group url = m.Groups["url"];
                        Group author = m.Groups["author"];
    
                        if (url != null && author != null)
                        {
                            //Debug.WriteLine("author: {0}\nUrl: {1}", author.Value, url.Value);
    
                            // Se caso tenha encontrado o link do artista (pois há outros links na página) continua
                            if(url.Value.ToLower().IndexOf("/artist/") > -1)
                            {
                                // Adiciona um objeto Artista à lista
                                Artista artista = new Artista(author.Value, url.Value);
                                _artistas.Add(artista);
                            }
                        }
                    }
    
                    listBox1.ItemsSource = _artistas;
    
                }
            }
