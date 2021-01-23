    Html.ActionLink(article.Title, 
                    "Item",   // <-- ActionMethod
                    "Login",  // <-- Controller Name.
                    new { ItemID = Model.ItemID }, // <-- Route arguments.
                    null  // <-- htmlArguments .. which are none. You need this value
                          //     otherwise you call the WRONG method ...
                    )
