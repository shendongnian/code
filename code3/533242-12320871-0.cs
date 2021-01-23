    [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
    [DataMemberAttribute()]
    public global::System.String EmployeeComment
    {
        get
        {
            return _EmployeeComment;
        }
        set
        {
            OnEmployeeCommentChanging(value);
            ReportPropertyChanging("EmployeeComment");
            _EmployeeComment = StructuralObject.SetValidValue(value, true);
            ReportPropertyChanged("EmployeeComment");
            OnEmployeeCommentChanged();
        }
    }
    private global::System.String _EmployeeComment;
    partial void OnEmployeeCommentChanging(global::System.String value);
    partial void OnEmployeeCommentChanged();
