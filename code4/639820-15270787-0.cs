    // collect needed info to make next queries in db
	var messageIdList = new Array();
	var jokeMessageIdList = new Array();
	var sourceUserIdList  = new Array();
	for( var i=0; i < messagesToAsk.length; i++ )
	{
		messageIdList.push( messagesToAsk[i].MessageId      );
		jokeMessageIdList.push( jokeMessageId[i].JokeMessageId  );
		sourceUserIdList .push( jokeMessageId[i].SourceUserId   );
	}
	// make requests to have all the data in place
	var messages = App.DataModels.Messages.find( {} );
		messages.where( 'MessageId' ).in( messageIdList );
		messages.exec( function ( err, foundMessages ) 
		{
			var jokeMessages = App.DataModels.Messages.find( {} );
				jokeMessages.where( 'JokeMessageId' ).in( jokeMessageIdList );
				jokeMessages.exec( function ( err, foundJokeMessages ) 
				{
					var users = App.DataModels.Messages.find( {} );
						users.where( 'SourceUserId' ).in( sourceUserIdList );
						users.exec( function ( err, foundUsers ) 
						{
							var messageList = new Array(); // new List<MessageHelper>();
							for( var i=0; i < messagesToAsk.length; i++ )
							{
								var message     = null;
								var jokeMessage = null;
								var user        = null;
								// get the data
								for( var j = 0; j < messages.length; j++ )
								{
									if( messages[j].MessageId === messagesToAsk[i].MessageId )
									{
										message = messages[j];
										break;
									}
								}
								for( var k = 0; k < jokeMessages.length; k++ )
								{
									if( jokeMessages[k].JokeMessageId === messagesToAsk[k].JokeMessageId )
									{
										jokeMessage = jokeMessage[k];
										break;
									}
								}
								for( var l = 0; l < users.length; l++ )
								{
									if ( users[l].SourceUserId === messagesToAsk[l].SourceUserId )
									{
										user = users[l];
										break;
									}
								}
								var messageHelper = 
								{
									"AskingUserId"  : user.Id,
									"AskingUserPic" : user.HelperPhoto,
									"Message"       : message,
									"JokeMessage"   : message.Type === "1" ? jokeMessage.Content
								};
								messageList.Add( messageHelper );
							}
							responseDelegate( response, messageList );
						});
				});
		});
