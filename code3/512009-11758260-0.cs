                <Rectangle Name="TransparentBack"  Height="10" Width="10">
                    <Rectangle.Fill>
                        <DrawingBrush>
                            <DrawingBrush.Drawing>
                                <DrawingGroup>
                                    <GeometryDrawing Brush="Transparent">
                                        <GeometryDrawing.Geometry>
                                            <RectangleGeometry>
                                                <RectangleGeometry.Rect>
                                                    <Rect Height="1" Width="1"/>
                                                </RectangleGeometry.Rect>
                                            </RectangleGeometry>
                                        </GeometryDrawing.Geometry>
                                    </GeometryDrawing>
                                    <GeometryDrawing Brush="White">
                                        <GeometryDrawing.Geometry>
                                            <PathGeometry>
                                                <PathFigure StartPoint="0,0">
                                                    <LineSegment Point="0,1"/>
                                                    <LineSegment Point="1,1"/>
                                                </PathFigure>
                                            </PathGeometry>
                                        </GeometryDrawing.Geometry>
                                    </GeometryDrawing>
                                </DrawingGroup>
                            </DrawingBrush.Drawing>
                        </DrawingBrush>
                    </Rectangle.Fill>
                </Rectangle>
