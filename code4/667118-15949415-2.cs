    <table class="inner">
                  @{int i = 0;}
                  
                  @foreach (var item in Model.Clients)
                      {
                          Int32 myId = Convert.ToInt32(item.DBID);
                          var myClient = db.Client.Where(c => c.Id == myId).First();
                        
                                <tr><td>@string.Format("{0} {1} {2}",myClient.Title,myClient.Initials,myClient.LastName)
                                        @if (myClient.Type!="Primary")
                                            {
                                            @Html.ActionLink("Delete", "Delete","ClientBackground", new { id=item.ID },null)
                                    }
                        </td></tr>
                  }
    </table>
