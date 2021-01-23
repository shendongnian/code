    <Grid>
        <Image Name="image" Source="C:\Users\Public\Pictures\Sample Pictures\Koala.jpg"/>
        <Path Fill="#AAFFFFFF">
            <Path.Data>
                <CombinedGeometry GeometryCombineMode="Xor">
                    <CombinedGeometry.Geometry1>
                        <RectangleGeometry Rect="0,0,10000,10000"/>
                    </CombinedGeometry.Geometry1>
                    <CombinedGeometry.Geometry2>
                        <RectangleGeometry x:Name="transparentRect" Rect="150,100,200,100"/>
                    </CombinedGeometry.Geometry2>
                </CombinedGeometry>
            </Path.Data>
        </Path>
    </Grid>
