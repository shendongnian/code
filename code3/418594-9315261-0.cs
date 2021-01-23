                var Cookie_Name = "MyTestCookie";
                var sessionValue = null;
                if (document.cookie) {
                    var currentDocumentCookie = document.cookie.split(';');
                    alert(document.cookie);
                    var lengthCookie = currentDocumentCookie.length;
                    for (j = 0; j < lengthCookie; j++) {
                        var singleCookie = currentDocumentCookie[j];
                        
                        alert(singleCookie);
                          
                        while (singleCookie.charAt(0) == ' ') {
                            singleCookie = singleCookie.substring(1, singleCookie.length);
                        }
             
                    }
                   return 1;
                }
                else {
                    return 0;
                }
            }
