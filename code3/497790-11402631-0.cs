    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    
    namespace TestDivLockScreen
    {
        /// <summary>
        /// Helper to "Synchronizer Token Pattern".
        /// </summary>
        public class SynchronizerToken
        {
            private static readonly string SESSION_KEY_TOKEN = "TestDivLockScreen.SynchronizedToken.SESSION_KEY_TOKEN";
    
            /// <summary>
            /// Returns a new token and positions it for validation of next request.
            /// </summary>
            /// <returns></returns>
            public static string NewToken()
            {
                string token = Guid.NewGuid().ToString("N");
                HttpContext.Current.Session.Add(SESSION_KEY_TOKEN, token);
                return token;
            }
    
            /// <summary>
            /// Returns the value of the current token. Renew if the current token is null.
            /// </summary>
            /// <returns></returns>
            public static string CurrentToken()
            {
                string token = HttpContext.Current.Session[SESSION_KEY_TOKEN] as string;
                if (string.IsNullOrEmpty(token))
                {
                    token = NewToken();
                }
    
                return token;
            }
    
            /// <summary>
            /// Checks if the token matches the token of last call to NewToken.
            /// The removal of the token is only made after a new call NewToken.
            /// </summary>
            /// <param name="token"></param>
            /// <returns></returns>
            public static bool IsCurrentToken(string token)
            {
                string currentToken = HttpContext.Current.Session[SESSION_KEY_TOKEN] as string;
                if (currentToken == null)
                {
                    return false;
                }
                else
                {
                    if (currentToken.Equals(token))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
    
            /// <summary>
            /// Do the same as IsCurrentToken. However loads a new "token value"
            /// in the session. Is "Thread Safe"!
            /// </summary>
            /// <param name="token"></param>
            /// <returns></returns>
            public static bool IsCurrentTokenRenew(string token)
            {
                lock (HttpContext.Current.Session)
                {
                    string currentToken = CurrentToken();
                    NewToken();
                    if (currentToken.Equals(token))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
