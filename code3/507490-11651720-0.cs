    Public Enum EThing
        eThingOne = 1
        eThingTwo = 2
    End Enum
    Private mThing As EThing
    Private Sub Class_Initialize()
        mThing = eThingOne
    End Sub
    Public Property Let Thing(newVal As EThing)
        mThing = newVal
    End Property
    Public Property Get Thing() As EThing
        Thing = mThing
    End Property
