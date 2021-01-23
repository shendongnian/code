    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace WebApplicationCS2
    {
        public partial class MultipleUsers : System.Web.UI.Page
        {
            private const string UserNameKey = "SitePlayer_UserName";
            private string CurrentUserName;
            private List<GameUser> lGameUsers;
            protected void Page_Load(object sender, EventArgs e)
            {
                HttpCookie playerCookie = Request.Cookies[UserNameKey];
                CurrentUserName = (playerCookie != null ? playerCookie.Value : null);
                if (CurrentUserName != null)
                {
                    // Update cache to indicate user is still online.
                    Cache.Add(UserNameKey + CurrentUserName, CurrentUserName, null,
                              System.Web.Caching.Cache.NoAbsoluteExpiration,
                              TimeSpan.FromMinutes(1), System.Web.Caching.CacheItemPriority.Normal, null);
                }
                lGameUsers = GetUserList();
                rptUsersList.DataSource = lGameUsers;
                rptUsersList.DataBind();
            }
            protected void btnSignin_Click(object sender, EventArgs e)
            {
                string chosenName = txtChosenName.Text.Trim();
                foreach (GameUser u in lGameUsers)
                {
                    if (string.Compare(chosenName, u.UserName, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        lblMessage.Text = "Username already in use.";
                        lblMessage.Visible = true;
                        return;
                    }
                }
                Cache.Add(UserNameKey + chosenName, chosenName, null,
                          System.Web.Caching.Cache.NoAbsoluteExpiration, 
                          TimeSpan.FromMinutes(1), System.Web.Caching.CacheItemPriority.Normal, null);
                Response.AppendCookie(new HttpCookie(UserNameKey, chosenName));
            }
            protected void lnkChallenge_Command(object sender, CommandEventArgs e)
            {
            }
            class GameUser
            {
                public string UserName { get; set; }
                public bool CanChallenge { get; set; }
            }
            private List<GameUser> GetUserList()
            {
                List<GameUser> userList = new List<GameUser>();
                foreach (System.Collections.DictionaryEntry cacheItem in Cache)
                {
                    if (cacheItem.Key.ToString().StartsWith(UserNameKey))
                    {
                        string name = cacheItem.Value.ToString();
                        if (string.Compare(CurrentUserName, name, StringComparison.OrdinalIgnoreCase) != 0)
                        {
                            GameUser u = new GameUser() 
                            {
                                UserName = name,
                                CanChallenge = (CurrentUserName != null)
                            };
                            userList.Add(u);
                        }
                    }
                }
                return userList;
            }
        }
    }
