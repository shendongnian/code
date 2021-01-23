        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="questiongroup">
                    <asp:HiddenField runat="server" ID="lblQuestionGroupId" Value='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "QuestionGroupId").ToString()) %>'>
                    </asp:HiddenField>
                    <asp:HiddenField runat="server" ID="hfSortOrder" Value='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "SortOrder").ToString()) %>'>
                    </asp:HiddenField>
                    <asp:HiddenField runat="server" ID="hdnPointsAwarded" Value='0'></asp:HiddenField>
                    <br />
                    <h3><asp:Label runat="server" ID="txtQuestionGroupName" MaxLength="50" Columns="50" Text='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "QuestionGroupName").ToString()) %>'></asp:Label>
                    </h3>
                    Score Section
                    <asp:CheckBox runat="server" ID="chkIsScoreSection" Enabled="false" TabIndex="-1"
                        Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsScoreSection")) %>' />
                    Minimum required correct answers:
                    <asp:Label runat="server" ID="lblMinimumForScore" MaxLength="3" Columns="3" Text='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "CommentsRequiredMinimumYesAnswers").ToString()) %>'></asp:Label>
                      Point Value <asp:Label ID="lblPossiblePoints" runat="server" Text='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "PossiblePoints").ToString()) %>' />
                              <br />
                    Group Instructions
                    <br />
                    <asp:Label runat="server" ID="lblGroupInstructions" TextMode="MultiLine" Columns="50" Rows="3"
                        Text='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "GroupInstructions").ToString()) %>'></asp:Label>
                    <br />
                    <div class='questionseditor'>
                    </div>
                    <br />
                    <div class="questionsdiv">
                        <asp:Repeater ID="childRepeater" runat="server" DataSource='<%# ((DataRowView)Container.DataItem).Row.GetChildRows("Relation2") %>'>
                            <ItemTemplate>
                            <div class="question">
                                <asp:HiddenField ID="hdnQuestionType" runat="server" Value='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "[\"QuestionTypeId\"]").ToString()) %>' />
                                <asp:HiddenField ID="hdnQuestionId" runat="server" Value='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "[\"QuestionId\"]").ToString()) %>' />
                                <asp:HiddenField ID="hfQuestionSortOrder" runat="server" Value='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "[\"SortOrder\"]").ToString()) %>' />
                                <asp:RequiredFieldValidator SetFocusOnError="True" ID="YesNoForScoreRequiredFieldValidator" runat="server"
                                    ControlToValidate="lstYesNoForScore" Display="Dynamic" ErrorMessage="Required<br />"
                                    Enabled='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "[\"QuestionTypeId\"]").ToString()) == "1" %>'></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator SetFocusOnError="True" ID="MemoRequiredFieldValidator" runat="server" ControlToValidate="txtMemoAnswer"
                                    Display="Dynamic" ErrorMessage="Required<br />" 
                                    Enabled='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "[\"QuestionTypeId\"]").ToString()) == "2" %>'></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator SetFocusOnError="True" ID="NumericAnswerRequiredFieldValidator" runat="server"
                                    ControlToValidate="txtNumericAnswer" Display="Dynamic" ErrorMessage="Required<br />"
                                    Enabled='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "[\"QuestionTypeId\"]").ToString()) == "3" %>'></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator SetFocusOnError="True" Display="Dynamic" runat="server" ID="NumericTextRegexValidator"
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" Enabled='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "[\"QuestionTypeId\"]").ToString()) == "3" %>'
                                    ErrorMessage="*Invalid<br />" ControlToValidate="txtNumericAnswer"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator SetFocusOnError="True" ID="RequiredFieldValidator1" runat="server" ControlToValidate="lstYesNoNonScored"
                                    Display="Dynamic" ErrorMessage="Required<br />" Enabled='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "[\"QuestionTypeId\"]").ToString()) == "5" %>'></asp:RequiredFieldValidator>
                                <asp:Label ID="lblQuestionText" runat="Server" Text='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "[\"QuestionText\"]").ToString()) %>'></asp:Label><br />
                                <asp:RadioButtonList runat="server" ID="lstYesNoForScore" RepeatDirection="Horizontal"
                                    Visible='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "[\"QuestionTypeId\"]").ToString()) == "1" %>'>
                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="No *" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:TextBox ID="txtMemoAnswer" runat="server" Visible='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "[\"QuestionTypeId\"]").ToString()) == "2" %>'
                                    TextMode="MultiLine" Rows="3" Width="100%"></asp:TextBox>
                                <asp:TextBox ID="txtNumericAnswer" runat="server" Visible='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "[\"QuestionTypeId\"]").ToString()) == "3" %>'
                                    cols="5"></asp:TextBox>
                                <uc1:MultipleChoiceControl ID="MultipleChoiceControl1" runat="server" Visible='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "[\"QuestionTypeId\"]").ToString()) == "4" %>'
                                    QuestionId='<%# Convert.ToInt32(DataBinder.Eval(Container.DataItem, "[\"QuestionId\"]")) %>' />
                                <asp:RadioButtonList runat="server" ID="lstYesNoNonScored" RepeatDirection="Horizontal"
                                    Visible='<%#  Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(  DataBinder.Eval(Container.DataItem, "[\"QuestionTypeId\"]").ToString()) == "5" %>'>
                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                                <br />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    Comments for this Question Group (Required if score not awarded)
                    <asp:TextBox ID="txtGroupComments" runat="server" TextMode="MultiLine" Rows="3" Width="100%"></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:Repeater>
