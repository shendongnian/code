            var engine =new Engine();
            var html = 
                        @"<script>
                            var apiresult = {
                                success: true,
                                data: {
                                    userName: ""xxxxx"",
                                    jsonData: { 
                                        ""id"" : ""8342859"",
                                        ""price"" : ""83.94""
                                        }
                                    }
                                };
                        </script>";
            var doc=new HtmlDocument();
            doc.LoadHtml(html);
            var script = doc.DocumentNode.SelectNodes("//script").First().InnerHtml;
            var result = engine
                .Execute(script)
                .Execute("var x=apiresult.data.jsonData;")
                .GetValue("x");
            var jsonData = engine.Json.Stringify(result, new[] { result });
