    // IEnumerable<Info>
    var items = infoList.Where(i => infoDic.ContainsKey(i.InfoText))
                        .Select(e => new Info
                                {
                                    InfoInt = infoDic[e.InfoText],
                                    InfoText = e.InfoText
                                });
