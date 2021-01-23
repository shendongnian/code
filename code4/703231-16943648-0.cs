    Imports System.Collections.ObjectModel
    Imports Microsoft.Maps.MapControl
    
    Namespace Binding_Bing_Map_Control.Modal
    	Public Class MapModal
    		Public Property Location As Location
            Public Property TooltipTex As String
    
    		Public Shared Function getMapRecords() As ObservableCollection(Of MapModal)
    			Dim MapRecords As New ObservableCollection(Of MapModal)()
    			MapRecords.Add(New MapModal() With { _
    				Key .MapLocation = New Location(47.610015, -122.188362), _
    				Key .TooltipText = "Main St, Bellevue, WA 98004" _
    			})
    			MapRecords.Add(New MapModal() With { _
    				Key .MapLocation = New Location(47.603562, -122.329496), _
    				Key .TooltipText = "James St, Seattle, wa 98104" _
    			})
    			MapRecords.Add(New MapModal() With { _
    				Key .MapLocation = New Location(47.609355, -122.18997), _
    				Key .TooltipText = "Main St, Bellevue, WA 98004-6405" _
    			})
    			MapRecords.Add(New MapModal() With { _
    				Key .MapLocation = New Location(47.61582, -122.238973), _
    				Key .TooltipText = "601 76th Ave, Medina ,WA 98039" _
    			})
    			Return MapRecords
    		End Function
    	End Class
    End Namespace
