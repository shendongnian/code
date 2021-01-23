        <WebMethod()> _
        <ScriptMethod(UseHttpGet:=True)> _
        Public Function get_time() As String
            'Cache the reponse to the client for 60 seconds:
            Dim context As HttpContext = HttpContext.Current
            Dim cacheExpires As New TimeSpan(0, 0, 0, 60)
            SetResponseHeaders(context, HttpCacheability.Public, cacheExpires)
            Return Date.Now.ToString
        End Function
        ''' <summary>
        ''' Sets the headers of the current http context response.
        ''' </summary>
        ''' <param name="context">A reference to the current context.</param>
        ''' <param name="cacheability">The cachability setting for the output.</param>
        ''' <param name="delta">The amount of time to cache the output. Set to Nothing if NoCache.</param>
        ''' <remarks></remarks>
        Public Shared Sub SetResponseHeaders(ByRef context As HttpContext,
                                             cacheability As HttpCacheability,
                                             delta As TimeSpan)
            If Not IsNothing(context) Then
                Dim cache As HttpCachePolicy = context.ApplicationInstance.Response.Cache
                cache.SetCacheability(cacheability)
                Select Case cacheability
                    Case HttpCacheability.NoCache
                        'prevent caching:
                        Exit Select
                    Case Else
                        'set cache expiry:
                        Dim dateExpires As Date = Date.UtcNow
                        dateExpires = dateExpires.AddMinutes(delta.TotalMinutes)
                        'set expiry date:
                        cache.SetExpires(dateExpires)
                        Dim maxAgeField As Reflection.FieldInfo = cache.GetType.GetField("_maxAge", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
                        If Not IsNothing(maxAgeField) Then
                            maxAgeField.SetValue(cache, delta)
                        End If
                End Select
            End If
        End Sub
