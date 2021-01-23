                                       var request = (HttpWebRequest)WebRequest.Create(profileurl);
                                        request.Method = "GET";
                                        using (var response = request.GetResponse())
                                        {
                                            using (var stream = response.GetResponseStream())
                                            {
                                                using (var reader = new StreamReader(stream, Encoding.UTF8))
                                                {
                                                    result = reader.ReadToEnd();
                                                }
                                                var doc = new HtmlDocument();
                                                doc.Load(new StringReader(result));
                                                var root = doc.DocumentNode;
                                                HtmlNode profileHeader = root.SelectSingleNode("//*[@id='profile-header']");
                                                HtmlNode profileRight = root.SelectSingleNode("//*[@id='profile-right']");
                                                string rankHtml = profileHeader.SelectSingleNode("//*[@id='best-team-1']").OuterHtml.Trim();
                                                #region GetPlayerAvatar
                                                var avatarMatch = Regex.Match(profileHeader.SelectSingleNode("/html/body/div/div[2]/div/div/div/div/div/span").OuterHtml, @"(portraits[^(h3)]+).*no-repeat;", RegexOptions.IgnoreCase);
                                                if (avatarMatch.Success)
                                                {
                                                    battleNetPlayerFromDB.PlayerAvatarCss = avatarMatch.Value;
                                                }
                                                #endregion
                                            }
                                        }
                                    }
                                    catch (WebException ex)
                                    {
                                    }
