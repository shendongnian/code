    <telerik:RadGridView AutoGenerateColumns="False" ShowGroupPanel="True" Name="gridView">
                <telerik:RadGridView.Columns>
                    <telerik:GridViewDataColumn DataMemberBinding="{Binding GroupByMe}" Header="Group By Me"   />
                    <telerik:GridViewDataColumn DataMemberBinding="{Binding DataForEditing}" Header="Data For Editing" />
                </telerik:RadGridView.Columns>
            </telerik:RadGridView>
