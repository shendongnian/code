    if ((int)response.StatusCode >= 400)
     {
          exceptionResponse = JsonConvert.DeserializeObject<ExceptionResponse>(LogRequisicao.CorpoResposta);
          LogRequisicao.CorpoResposta = exceptionResponse.ToString() ;
          if (exceptionResponse.InnerException != null)
                 LogRequisicao.CorpoResposta += "\r\n InnerException: " + exceptionResponse.ToString();
     }
