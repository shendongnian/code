                var oAuthMembership = new EndeavorODataEntities().webpages_OAuthMembership
                    .Where(u => u.ProviderUserId == result.ProviderUserId)
                    .FirstOrDefault(x => x.Provider == result.Provider) ?? 
                    new webpages_OAuthMembership
                            {
                                Provider = result.Provider,
                                ProviderUserId = result.ProviderUserId,
                            };
                TempData.Add("OAuthMembership", oAuthMembership);
                HttpContext.Response.Cookies.Add(new HttpCookie("UserId", oAuthMembership.UserId.ToString(CultureInfo.InvariantCulture)));
                return RedirectToAction("Summary", new { Controller = "Member", id = oAuthMembership.UserId.ToString(CultureInfo.InvariantCulture) });
