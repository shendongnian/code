    <UserControl.Resources>
        <DataTemplate DataType="{x:Type vm:GenericQuestionViewModel}">
            <v:GenericQuestion/>
        </DataTemplate>
        <DataTemplate DataType="{x:Type tvm:GeographyQuestionViewModel}">
            <tv:GeographyQuestion/>
        </DataTemplate>
        <DataTemplate DataType="{x:Type tvm:BiologyQuestionViewModel}">
            <tv:BiologyQuestion/>
        </DataTemplate>
    </UserControl.Resources>
    <ContentControl Content="{Binding QuestionViewModel}">
