    Public Class LineData
    	Public Property Point1() As Point
    	Public Property Point2() As Point
    	Public ReadOnly Property Slope() As Double
    		Get
    			# 0=Horizontal Line, NaN=Vertical Line
    			Return If(Me.Point1.X = Me.Point2.X, Double.NaN, (Me.Point1.Y - Me.Point2.Y) / (Me.Point1.X - Me.Point2.X))
    		End Get
    	End Property
    	Public ReadOnly Property YIntercept() As Double
    		Get
    			Return If(Double.IsNaN(Me.Slope), Double.NaN, Me.Point1.Y - Me.Slope * Me.Point1.X)
    		End Get
    	End Property
    	Public ReadOnly Property Angle() As Double
    		Get
    			Return If(Double.IsNaN(Me.Slope), Math.PI / 2, Math.Atan(Me.Slope))
    		End Get
    	End Property
    
    	Public Sub New(pt1 As Point, pt2 As Point)
    		Me.Point1 = pt1
    		Me.Point2 = pt2
    	End Sub
    	Public Sub New(x1 As Double, y1 As Double, x2 As Double, y2 As Double)
    		Me.Point1 = New Point(x1, y1)
    		Me.Point2 = New Point(x2, y2)
    	End Sub
    	Public Sub New(ln As Line)
    		Me.New(ln.X1, ln.Y1, ln.X2, ln.Y2)
    	End Sub
    
    	Public Function GetParallel(spacing As Double) As LineData
    		Return Me.GetParallel(spacing, ParallelPosition.Below)
    	End Function
    
    	Public Function GetParallel(spacing As Double, pos As ParallelPosition) As LineData
    		If Me.Slope = 0 Then # Horizontal Line
    			If pos = ParallelPosition.Above OrElse pos = ParallelPosition.Left Then : Return If(Me.Point2.X > Me.Point1.X, New LineData(Me.Point1.X - spacing, Me.Point1.Y - spacing, Me.Point2.X + spacing, Me.Point2.Y - spacing), New LineData(Me.Point1.X + spacing, Me.Point1.Y - spacing, Me.Point2.X - spacing, Me.Point2.Y - spacing))
    			Else : Return If(Me.Point2.X > Me.Point1.X, New LineData(Me.Point1.X - spacing, Me.Point1.Y + spacing, Me.Point2.X + spacing, Me.Point2.Y + spacing), New LineData(Me.Point1.X + spacing, Me.Point1.Y + spacing, Me.Point2.X - spacing, Me.Point2.Y + spacing))
    			End If
    		ElseIf Double.IsNaN(Me.Slope) Then # Vertical Line
    			If pos = ParallelPosition.Above OrElse pos = ParallelPosition.Left Then : Return If(Me.Point2.Y > Me.Point1.Y, New LineData(Me.Point1.X - spacing, Me.Point1.Y - spacing, Me.Point2.X - spacing, Me.Point2.Y + spacing), New LineData(Me.Point1.X - spacing, Me.Point1.Y + spacing, Me.Point2.X - spacing, Me.Point2.Y - spacing))
    			Else : Return If(Me.Point2.Y > Me.Point1.Y, New LineData(Me.Point1.X + spacing, Me.Point1.Y - spacing, Me.Point2.X + spacing, Me.Point2.Y + spacing), New LineData(Me.Point1.X + spacing, Me.Point1.Y + spacing, Me.Point2.X + spacing, Me.Point2.Y - spacing))
    			End If
    		Else #Sloped Line
    			Dim verticalshift As Double = Math.Abs(spacing / Math.Cos(-Me.Angle))
    			Dim horizontalshift As Double = Math.Abs(spacing / Math.Sin(-Me.Angle))
    			If Math.Sign(Me.Slope) = -1 Then
    				If Me.Point2.X > Me.Point1.X Then
    					If pos = ParallelPosition.Above OrElse pos = ParallelPosition.Left Then : Return New LineData(Me.Point1.X - horizontalshift, Me.Point1.Y, Me.Point2.X, Me.Point2.Y - verticalshift)
    					Else : Return New LineData(Me.Point1.X, Me.Point1.Y + verticalshift, Me.Point2.X + horizontalshift, Me.Point2.Y)
    					End If
    				Else
    					If pos = ParallelPosition.Above OrElse pos = ParallelPosition.Left Then : Return New LineData(Me.Point1.X, Me.Point1.Y - verticalshift, Me.Point2.X - horizontalshift, Me.Point2.Y)
    					Else : Return New LineData(Me.Point1.X + horizontalshift, Me.Point1.Y, Me.Point2.X, Me.Point2.Y + verticalshift)
    					End If
    				End If
    			Else
    				If Me.Point2.X > Me.Point1.X Then
    					If pos = ParallelPosition.Above OrElse pos = ParallelPosition.Right Then : Return New LineData(Me.Point1.X, Me.Point1.Y - verticalshift, Me.Point2.X + horizontalshift, Me.Point2.Y)
    					Else : Return New LineData(Me.Point1.X - horizontalshift, Me.Point1.Y, Me.Point2.X, Me.Point2.Y + verticalshift)
    					End If
    				Else
    					If pos = ParallelPosition.Above OrElse pos = ParallelPosition.Right Then : Return New LineData(Me.Point1.X + horizontalshift, Me.Point1.Y, Me.Point2.X, Me.Point2.Y - verticalshift)
    					Else : Return New LineData(Me.Point1.X, Me.Point1.Y + verticalshift, Me.Point2.X - horizontalshift, Me.Point2.Y)
    					End If
    				End If
    			End If
    		End If
    	End Function
    
    	Public Function CalculateX(y As Double) As Double
    		If Me.Slope = 0 Then # Horizontal Line
    			If y = Me.Point1.Y OrElse y = Me.Point2.Y Then Return 0 Else Return Double.NaN
    		ElseIf Double.IsNaN(Me.Slope) Then # Vertical Line
    			Return Me.Point1.X
    		Else
    			Return (y - Me.YIntercept) / Me.Slope
    		End If
    	End Function
    	Public Function CalculateY(x As Double) As Double
    		If Me.Slope = 0 Then # Horizontal Line
    			Return Me.Point1.Y
    		ElseIf Double.IsNaN(Me.Slope) Then # Vertical Line
    			If x = Me.Point1.X OrElse x = Me.Point2.X Then Return 0 Else Return Double.NaN
    		Else
    			Return Me.Slope * x + Me.YIntercept
    		End If
    	End Function
    
    	Public Function GetIntersection(ln As LineData) As Point
    		If Me.Slope = ln.Slope OrElse (Double.IsNaN(Me.Slope) AndAlso Double.IsNaN(ln.Slope)) Then : Return Nothing
    		Else
    			If Double.IsNaN(Me.Slope) Then : Return New Point(Me.Point1.X, ln.CalculateY(Me.Point1.X))
    			ElseIf Double.IsNaN(ln.Slope) Then : Return New Point(ln.Point1.X, Me.CalculateY(ln.Point1.X))
    			ElseIf Me.Slope = 0 Then : Return New Point(ln.CalculateX(Me.Point1.Y), Me.Point1.Y)
    			ElseIf ln.Slope = 0 Then : Return New Point(Me.CalculateX(ln.Point1.Y), ln.Point1.Y)
    			Else
    				Dim x As Double = (Me.YIntercept - ln.YIntercept) / (ln.Slope - Me.Slope)
    				Return New Point(x, Me.CalculateY(x))
    			End If
    		End If
    	End Function
    
    	Public Function GetLine() As Line
    		Dim templine As New Line
    		templine.X1 = Me.Point1.X
    		templine.Y1 = Me.Point1.Y
    		templine.X2 = Me.Point2.X
    		templine.Y2 = Me.Point2.Y
    		Return templine
    	End Function
    End Class
    
    Public Enum ParallelPosition As Byte
    	Above
    	Below
    	Left
    	Right
    End Enum
