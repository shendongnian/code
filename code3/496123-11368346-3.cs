        <asp:ScriptManager runat="server" ID="scriptManager" />
        <asp:Button Text="Full Post" runat="server" />
        <br />
        <asp:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DropDownList runat="server" ID="ddl1OnPanel1" AutoPostBack="true" OnSelectedIndexChanged="ddl1OnPanel1_SelectedIndexChanged">
                    <asp:ListItem Text="text1" />
                    <asp:ListItem Text="text2" />
                </asp:DropDownList>
                <br />
                <asp:DropDownList runat="server" ID="ddl2OnPanel1" AutoPostBack="true" OnSelectedIndexChanged="ddl2OnPanel1_SelectedIndexChanged">
                    <asp:ListItem Text="text3" />
                    <asp:ListItem Text="text4" />
                </asp:DropDownList>
                <br />
                <asp:Label runat="server" ID="lblMessageOnPanel1" />
                <br />
                <asp:Button ID="Button1" Text="text" runat="server" />
                <br />
                On every post on Panel 1: <%:DateTime.Now %>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <asp:UpdatePanel runat="server" ID="up2" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Calendar ID="calendarOnPanel2" runat="server" >
                    <DayHeaderStyle CssClass="dayheaderStyle" />
                    <NextPrevStyle />
                    <OtherMonthDayStyle BackColor="#ffffff" />
                    <SelectedDayStyle />
                    <TitleStyle CssClass="titleStyle" />
                    <TodayDayStyle BackColor="#ffffa0" ForeColor="#6699cc" />
                    <WeekendDayStyle />
                    <DayStyle CssClass="dayStyle" />
                </asp:Calendar>
                <br />
                <asp:Label ID="lblMessageOnPanel2" runat="server" />
                <br />
                On every post On Panel 2: <%:DateTime.Now %>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddl1OnPanel1" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
