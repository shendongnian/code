    <div>
                                @if (Model.ChildCommentList != null)
                                {
                                    foreach (var childcomments in Model.ChildCommentList)
                                    {
                                        @Html.Raw(Nop.Core.Html.HtmlHelper.FormatText(childcomments.CommentText, false, true, false, false, false, false))
                                    }
                                }
                            </div>
