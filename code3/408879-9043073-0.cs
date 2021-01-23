                                   <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
    <asp:Repeater ID="Repeater1" runat="server" 
                                    OnItemCommand="MyButtonCommandEvent">
                                    <ItemTemplate>
                                        <div class="post">
                                            <asp:HiddenField ID="postID_hidden" runat="server" 
                                                Value='<%# DataBinder.Eval(Container.DataItem,"posts_ID") %>' />
                                            <div class="Thumb">
                                                <img src="thumbs/abdo_thumb.jpg"> </img></div>
                                            <span class="user"><%#DataBinder.Eval(Container.DataItem, "poster_name")%>
                                            </span>
                                            <div class="post-body">
                                                <p>
                                                    <%#DataBinder.Eval(Container.DataItem,"description")%>
                                                </p>
                                            </div>
                                            <div class="post-options" style=" height:22px; ">
                                                <span class="first"><%#DataBinder.Eval(Container.DataItem,"post_date")%></span>
                                                <ul style="display:inline; list-style-type: none;">
                                                    <li>
                                                        <div class="tooltip">
                                                            Comments
                                                            <img class="tool-img" src="Images/comments.png"> : <%#DataBinder.Eval(Container.DataItem,"comment_num") %> 
                                                            </img>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div class="tooltip">
                                                            <asp:LinkButton ID="like_linkbtn" runat="server" CommandName="Like"><%#(DataBinder.Eval(Container.DataItem, "name_like").ToString() == "") ? "Like" : DataBinder.Eval(Container.DataItem, "name_like")%></asp:LinkButton>
                                                            <img class="tool-img" src="images/likes.png"> : <%#DataBinder.Eval(Container.DataItem,"like_counter") %>
                                                            </img></div>
                                                    </li>
                                                    <li>
                                                        <div class="tooltip">
                                                            <asp:LinkButton ID="hate_linkbtn" runat="server" CommandName="Hate"><%#(DataBinder.Eval(Container.DataItem, "name_hate").ToString() == "") ? "Hate" : DataBinder.Eval(Container.DataItem, "name_hate")%></asp:LinkButton>
                                                            <img class="tool-img" src="images/hate.png"> : <%#DataBinder.Eval(Container.DataItem,"hate_counter") %>
                                                            </img></div>
                                                    </li>
                                                </ul>
                                            </div>
                                            <div class="finish">
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
    
                                        </ContentTemplate>
                        </asp:UpdatePanel>
