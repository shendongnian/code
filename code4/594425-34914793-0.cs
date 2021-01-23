                ...your form here...
                 <tr>
                    <td colspan="3" style="text-align: center" valign="top">
                        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="Submit_Click" CausesValidation="true"  />
                        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClick="Cancel_Click" CausesValidation="false"  />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    ...
        protected void Submit_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
               //processing done after a successful submit here!
            }
        }
