    Mapper.CreateMap<FormAnswer, FormAnswerModel>()
    				.ForMember(d => d.Answer, o => o.ResolveUsing(fa =>
    					{
    						string answer = String.Empty;
    						if (fa.AnswerBool.HasValue)
    						{
    							return fa.AnswerBool.Value;
    						}
    
    						if(fa.AnswerCurrency.HasValue)
    						{
    							return fa.AnswerCurrency.Value;
    						}
    
    						if(fa.AnswerDateTime.HasValue)
    						{
    							return fa.AnswerDateTime;
    						}
    
    						if(!String.IsNullOrEmpty(fa.AnswerString))
    						{
    							return fa.AnswerString;
    						}
    
    						return answer;
    					}
    				                               	));
