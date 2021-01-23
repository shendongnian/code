				//Track current identity before proxy call
                IPrincipal user = context.User;
                proxyRequestResultDetails = ProxyApiWrapper.GetProxies(
                    adUserInfo.AssociateId,
                    context.User);
                //Undo any impersonating done in the GetProxies call
                context.User = user;	
				
